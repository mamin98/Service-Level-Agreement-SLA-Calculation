import { Routes } from '@angular/router';
import { SlaComponent } from '../components/sla/sla'; 

export const routes: Routes = [
  { path: '', component: SlaComponent },
  { path: '**', redirectTo: '' }
];
