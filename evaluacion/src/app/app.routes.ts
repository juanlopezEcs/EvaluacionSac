import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';


const routes: Routes = [
    { path: 'loggin', component: LoginComponent }
];

exports: [ RouterModule ]