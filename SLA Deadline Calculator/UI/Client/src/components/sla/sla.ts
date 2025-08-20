import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SlaService } from '../../services/sla';
import { PriorityType } from '../../models/enum';  

@Component({
  selector: 'app-sla',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './sla.component.html',
  styleUrls: ['./sla.component.scss']
})
export class SlaComponent {
  slaList: any[] = [];
  newSla: any = { name: '', captureDateTime: '', priority: null };

  priorityTypes = Object.entries(PriorityType)
    .filter(([_, value]) => typeof value === 'number')
    .map(([key, value]) => ({ name: key, value: value as number }));

  constructor(private slaService: SlaService) { }

  addSla() {
    const request = {
      priority: this.newSla.priority,
      captureDateTime: this.newSla.captureDateTime
    };

    this.slaService.calculateDeadline(request).subscribe(response => {
      this.slaList.push({
        name: this.newSla.name,
        captureDateTime: this.newSla.captureDateTime,
        priority: this.priorityTypes.find(p => p.value === this.newSla.priority)?.name,
        deadline: response.deadline
      });

      this.newSla = { name: '', captureDateTime: '', priority: null };
    });
  }
}
