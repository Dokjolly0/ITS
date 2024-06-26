import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { authGuard as AuthGuard } from '../app/guards/auth.guard';
import { TodoCardComponent } from './components/todo.card/todo.card.component';
import { RegisterComponent } from './components/register/register.component';
import { AmiciComponent } from './components/amici/amici.component';
import { UserCardComponent } from './components/user-card/user-card.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard],
  },
  { path: 'todo-card', component: TodoCardComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'amici', component: AmiciComponent },
  { path: '404', component: NotFoundComponent },
  { path: 'user-card', component: UserCardComponent },
  { path: '**', redirectTo: '404' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
