import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  expenses: any[] = [];
  private apiUrl = 'https://localhost:5123/';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadExpenses();
  }

  loadExpenses(): void {
    this.http.get<any[]>(this.apiUrl).subscribe(data => this.expenses = data);
  }

  addExpense(event: Event): void {
    event.preventDefault();
    const form = event.target as HTMLFormElement;
    const formData = new FormData(form);

    const expense = {
      description: formData.get('description'),
      amount: formData.get('amount'),
      date: formData.get('date'),
      category: formData.get('category')
    };

    this.http.post(this.apiUrl, expense).subscribe(() => {
      this.loadExpenses();
      form.reset();
    });
  }

  deleteExpense(id: string): void {
    this.http.delete(`${this.apiUrl}/${id}`).subscribe(() => this.loadExpenses());
  }
}
