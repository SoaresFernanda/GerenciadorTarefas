import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-modal-tarefa',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    MatButtonModule,
    MatOptionModule,
    MatSelectModule
  ],
  templateUrl: './modal-tarefa.html',
  styleUrls: ['./modal-tarefa.scss']
})
export class ModalTarefa {
  form: FormGroup;
  isEdicao: boolean;

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<ModalTarefa>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.isEdicao = !!data?.id;
    this.form = this.fb.group({
      titulo: [data?.titulo || ''],
      descricao: [data?.descricao || ''],
      status: [data?.status ?? 0],
    });
  }

  salvar() {
    if (this.form.valid) {
      this.dialogRef.close(this.form.value);
    }
  }

  fechar() {
    this.dialogRef.close();
  }
}