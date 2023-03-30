import { Component, Input, OnInit } from '@angular/core';
import { Slot } from 'src/app/_models/slot';
import { Iron } from '../../_models/iron';

@Component({
  selector: 'app-iron',
  templateUrl: './iron.component.html',
  styleUrls: ['./iron.component.css']
})
export class IronComponent implements OnInit {
  @Input() iron: Iron | undefined;
  @Input() officeId: number | undefined;

  topRow: Slot[] | undefined;
  bottomRow: Slot[] | undefined;

  ngOnInit(): void {
    this.splitSlots();
  }

  splitSlots() {
    if (this.iron !== undefined) {
      const half_length = Math.ceil(this.iron.slots.length / 2);

      this.topRow = this.iron.slots.slice(0, half_length);
      this.bottomRow = this.iron.slots.slice(half_length);
    }
  }

}
