import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css'
})
export class FormComponent implements OnInit {
  contatoForm!: FormGroup;

  formInit() {
    this.contatoForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(300), Validators.minLength(3)]),
      email: new FormControl('', [Validators.required, Validators.email]),
      estado: new FormControl('', Validators.required),
      cidade: new FormControl('', Validators.required),
      instituicao: new FormControl('', [Validators.required, Validators.maxLength(300), Validators.minLength(3)])
    });
  }

  ngOnInit() {
    this.formInit();
  }

  onSubmit() {
    if (this.contatoForm.valid) {
      console.log(this.contatoForm.value);
    } else {
      console.log('Form is invalid');
    }
  }

}
