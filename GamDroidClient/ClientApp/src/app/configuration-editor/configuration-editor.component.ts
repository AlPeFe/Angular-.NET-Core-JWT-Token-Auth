import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-configuration-editor',
  templateUrl: './configuration-editor.component.html',
  styleUrls: ['./configuration-editor.component.css']
})
export class ConfigurationEditorComponent implements OnInit {

  constructor() { }
  configuration = new FormControl('');
  ngOnInit() {
  }

}
