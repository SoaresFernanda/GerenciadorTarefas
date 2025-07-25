import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tarefa } from '../models/tarefa.model';
import { environment } from '../../environments/environment.server';
import { EditarTarefa } from '../models/editar-tarefa.model';

@Injectable({
  providedIn: 'root'
})

export class TarefaService {
  private apiURL = `${environment.apiUrl}/Tarefas`;


  constructor(private http: HttpClient) { }

  listarTarefas(): Observable<Tarefa[]> {
    return this.http.get<Tarefa[]>(this.apiURL);
  }
  criarTarefa(tarefa: Partial<Tarefa>): Observable<Tarefa> {
    return this.http.post<Tarefa>(this.apiURL, tarefa);
  }
  editarTarefa(id: string, tarefa: Partial<EditarTarefa>): Observable<EditarTarefa> {
    return this.http.patch<EditarTarefa>(`${this.apiURL}/${id}`, tarefa);
  }
  alterarStatusTarefa(id: string, status: Tarefa['status']): Observable<void> {
    return this.http.patch<void>(`${this.apiURL}/${id}/status`, {
      NovoStatus: status
    });
  }
  removerTarefa(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiURL}/${id}`);
  }
}
