import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LogEntry } from '../models/log-entry';

@Injectable({ providedIn: 'root' })
export class DistributedLoggingService {
  baseURL = 'https://localhost:7104/' + 'v1/logs';

  constructor(private http: HttpClient) {}

  saveLogEntry(logEntry: LogEntry): Observable<any> {
    return this.http.post<LogEntry>(`${this.baseURL}`, logEntry);
  }

  getLogEntries(): Observable<LogEntry[]> {
    return this.http.get<LogEntry[]>(`${this.baseURL}`);
  }

  getAllLogEntries(): Observable<LogEntry[]> {
    return this.http.get<LogEntry[]>(`${this.baseURL}` + `/AllLogs`);
  }

  deleteLogEntry(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.baseURL}/${id}`);
  }
}
