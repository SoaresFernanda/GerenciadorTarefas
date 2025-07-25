import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TarefasLista } from './tarefas-lista';

describe('TarefasLista', () => {
  let component: TarefasLista;
  let fixture: ComponentFixture<TarefasLista>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TarefasLista]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TarefasLista);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
