export interface LogEntry {
  id: number;
  service: string;
  level: string;
  message: string;
  timestamp: Date;
}
