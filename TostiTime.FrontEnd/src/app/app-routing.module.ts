import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OfficeComponent } from './_components/office/office.component';

const routes: Routes = [
  { path: 'office/:selectedOffice', component: OfficeComponent },
  { path: '**', redirectTo: '/office/Rotterdam', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
