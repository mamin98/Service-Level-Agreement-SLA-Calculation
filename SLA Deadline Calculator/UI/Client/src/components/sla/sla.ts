import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SlaService } from '../../services/sla';

@Component({
  selector: 'app-sla',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './sla.html',
  styleUrls: ['./sla.scss']
})
export class SlaComponent implements OnInit {
  slaList: any[] = [];
  newSla: any = { name: '', deadline: '' };

  constructor(private slaService: SlaService) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.slaService.getAll().subscribe(data => {
      this.slaList = data;
    });
  }

  addSla() {
    this.slaService.create(this.newSla).subscribe(() => {
      this.newSla = { name: '', deadline: '' };
      this.loadData();
    });
  }
}
