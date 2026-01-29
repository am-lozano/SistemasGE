import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, Validators } from '@angular/forms';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-formulario-reactivo',
  imports: [],
  templateUrl: './formulario-reactivo.html',
  styleUrl: './formulario-reactivo.css',
})
export class FormularioReactivo implements OnInit {

  formulario!: FormGroup;

  constructor() {

  }

  ngOnInit(): void {

    this.formulario = new FormGroup(
      {
        nombre: new FormControl('', [Validators.required]),
        apellidos: new FormControl('', [])
      }
    );
  }

  saluda() {
    if (this.formulario.valid) {
      alert('Hola ' + this.formulario.controls['nombre'].value + ' ' + this.formulario.controls['apellidos'].value);
    }

  }
}
