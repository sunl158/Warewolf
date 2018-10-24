import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RoleGuardService as RoleGuard } from '../guards/role-guard.service';
import { ExecutionLoggingComponent } from '../components/executionlogging/executionlogging.component';
import { SettingsComponent } from '../components/settings/settings.component';
import { CustomMaterialModule } from "./custommaterial.module";

const appRoutes: Routes = [
  { path: '', component: ExecutionLoggingComponent },
  { path: 'executionlogging', component: ExecutionLoggingComponent },
  { path: 'settings', component: SettingsComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes, { useHash: true }),
    CustomMaterialModule
  ],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule { }
