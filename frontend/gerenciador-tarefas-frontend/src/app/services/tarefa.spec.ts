import { Tarefa } from '../models/tarefa.model';

describe('Tarefa', () => {
  let tarefa: Tarefa;

  beforeEach(() => {
    tarefa = { id: '1', titulo: 'Teste', descricao: 'Descrição do teste', status: 0 };
  });

  it('should be created', () => {
    expect(tarefa).toBeTruthy();
  });
});