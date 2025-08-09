import { Component, OnInit } from '@angular/core';
import { SlaService } from '../../services/sla';

@Component({
  selector: 'app-sla',
  templateUrl: './sla.component.html',
  styleUrls: ['./sla.component.scss']
})
export class SlaComponent implements OnInit {
  slaList: any[] = [];
  newSla: any = { name: '', deadline: '' };

  constructor(private slaService: SlaService) {}

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
