import { Component } from '@angular/core';
import { CardComponent } from '../card/card.component';
import { BotaoComponent } from '../botao/botao.component';

@Component({
  selector: 'app-formulario',
  standalone: true,
  imports: [CardComponent, BotaoComponent],
  templateUrl: './formulario.component.html',
  styleUrl: './formulario.component.css'
})
export class FormularioComponent {

}
