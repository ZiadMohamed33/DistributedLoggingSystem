import { Component, OnInit } from '@angular/core';
import { LogEntry } from './models/log-entry';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'distributedloggingsystem.client';
  logs: LogEntry[] = [];

  constructor(private authService: AuthService) {}
  ngOnInit() {
    this.getToken();
  }

  getToken(): void {
    this.authService.getToken().subscribe();
  }
}
