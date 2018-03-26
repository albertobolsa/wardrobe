export class LogMessage {
    message: string;
    timestamp: string;
    logLevel: number;
    source: string = 'Client';
    stacktrace: string = '';
}