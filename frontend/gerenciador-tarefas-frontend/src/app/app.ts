import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TarefasLista } from './tarefas-lista/tarefas-lista';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TarefasLista],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
}
