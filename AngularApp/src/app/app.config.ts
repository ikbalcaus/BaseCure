import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { Router, provideRouter, withViewTransitions } from '@angular/router';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule, provideHttpClient, withFetch, withInterceptorsFromDi } from '@angular/common/http';
import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { InterceptorService } from './services/interceptor.service';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';

class CustomTranslateLoader implements TranslateLoader {
  constructor(
    private http: HttpClient,
    private router: Router
  ) {}

  public getTranslation(language: string) {
    return this.http.get("./assets/i18n/" + language + ".json");
  }
}

function createTranslateLoader(http: HttpClient, router: Router) {
  return new CustomTranslateLoader(http, router);
}

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes, withViewTransitions()),
    provideClientHydration(),
    provideHttpClient(withFetch(), withInterceptorsFromDi()),
    importProvidersFrom(HttpClientModule),
    importProvidersFrom(TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader , 
        useFactory: createTranslateLoader , 
        deps: [HttpClient, Router]
      },
      defaultLanguage: window.localStorage.getItem("language") || "ba"
    })),
    { provide: HTTP_INTERCEPTORS, useClass: InterceptorService, multi: true }
  ]
};
