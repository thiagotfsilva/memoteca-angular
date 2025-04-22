import { Component } from '@angular/core';
import { TitleComponent } from '../title/title.component';
import { FormularioComponent } from '../formulario/formulario.component';

@Component({
  selector: 'app-section-main',
  standalone: true,
  imports: [TitleComponent, FormularioComponent],
  templateUrl: './section-main.component.html',
  styleUrl: './section-main.component.css'
})
export class SectionMainComponent {

}
