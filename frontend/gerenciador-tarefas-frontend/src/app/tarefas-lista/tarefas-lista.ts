import { Component, OnInit } from '@angular/core';
import { Tarefa } from '../models/tarefa.model';
import { TarefaService } from '../services/tarefa';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialog } from '@angular/material/dialog';
import { ModalTarefa } from '../modal-tarefa/modal-tarefa';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { EditarTarefa } from '../models/editar-tarefa.model';

@Component({
  standalone: true,
  imports: [MatTableModule, MatButtonModule, MatIconModule, MatFormFieldModule, MatSelectModule, MatOptionModule, CommonModule],
  selector: 'app-tarefas-lista',
  templateUrl: './tarefas-lista.html',
  styleUrls: ['./tarefas-lista.scss']
})
export class TarefasLista implements OnInit {

  tarefas: Tarefa[] = [];
  tarefasFiltradas: Tarefa[] = [];
  statusFiltro: string = '';

  colunas: string[] = ['titulo', 'descricao', 'status', 'acoes'];
  statusList: number[] = [0, 1, 2];

  constructor(private dialog: MatDialog, private tarefaService: TarefaService) { }

  ngOnInit(): void {
    this.carregarTarefas();
  }

  carregarTarefas() {
    this.tarefaService.listarTarefas().subscribe((dados: Tarefa[]) => {
      this.tarefas = dados;
      this.filtrarPorStatus();
    });
  }

  filtrarPorStatus() {
    this.tarefasFiltradas = this.statusFiltro
      ? this.tarefas.filter(t => t.status === Number(this.statusFiltro))
      : [...this.tarefas];
  }

  novaTarefa() {
    const dialogRef = this.dialog.open(ModalTarefa, {
      width: '400px',
      data: null
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.tarefaService.criarTarefa(result).subscribe({
          next: () => {
            alert('Tarefa criada com sucesso!');
            this.carregarTarefas();
          },
          error: (erro) => {
            alert('Erro ao criar a tarefa: ' + erro.error);
          }
        });
      }
    });
  }

  alterarStatus(id: string, novoStatus: Tarefa['status']) {
    this.tarefaService.alterarStatusTarefa(id, novoStatus).subscribe({
      next: () => {
        alert('Status alterado com sucesso!');
        this.carregarTarefas();
      },
      error: (erro) => {
        alert('Erro ao alterar o status: ' + erro.error);
      }
    });
  }
  getStatusLabel(status: number): string {
    switch (status) {
      case 0: return 'Pendente';
      case 1: return 'Em Andamento';
      case 2: return 'Concluída';
      default: return 'Desconhecido';
    }
  }
  abrirModalEditar(tarefa: Tarefa) {
    const dialogRef = this.dialog.open(ModalTarefa, {
      width: '400px',
      data: { ...tarefa }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const dadosEdicao: EditarTarefa = {
          novoTitulo: result.titulo,
          novaDescricao: result.descricao
        };

        this.tarefaService.editarTarefa(tarefa.id, dadosEdicao).subscribe({
          next: () => {
            if (result.status !== tarefa.status) {
              this.tarefaService.alterarStatusTarefa(tarefa.id, result.status).subscribe({
                next: () => {
                  alert('Tarefa editada com sucesso!');
                  this.carregarTarefas();
                },
                error: (erro) => {
                  alert('Erro ao alterar o status: ' + erro.error);
                }
              });
            } else {
              alert('Tarefa editada com sucesso!');
              this.carregarTarefas();
            }
          },
          error: (erro) => {
            alert('Erro ao editar a tarefa: ' + erro.error);
          }
        });
      }
    });
  }

  removerTarefa(tarefa: Tarefa) {
    if (confirm('Tem certeza que deseja remover esta tarefa?')) {
      this.tarefaService.removerTarefa(tarefa.id).subscribe({
        next: () => {
          alert('Tarefa removida com sucesso!');
          this.carregarTarefas();
        },
        error: (erro) => {
          alert('Erro ao remover a tarefa: ' + erro.error);
        }
      });
    }
  }
}
