
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from '../src/app/app.module';
import {enableProdMode} from '@angular/core';

enableProdMode();
platformBrowserDynamic().bootstrapModule(AppModule);
