import { Component, OnInit } from '@angular/core';
import { NotifierService } from '../services/notifier.service';

@Component({
  selector: 'app-notifier',
  templateUrl: './notifier.component.html',
  styleUrls: ['./notifier.component.css']
})
export class NotifierComponent implements OnInit {

  constructor(public notifier: NotifierService) { }

  ngOnInit() {
  }

}
