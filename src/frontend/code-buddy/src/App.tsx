
import { routes } from "./router/routes";
import i18n from "i18next";
import LanguageDetector from 'i18next-browser-languagedetector';
import { initReactI18next } from "react-i18next";
import Backend from 'i18next-http-backend';
import { Provider } from "react-redux";
import { store } from "./store/store";
import { useConfig } from "./config";
import { Loading } from "./components/loading";
import { Auth0Provider } from "@auth0/auth0-react";
import { Authenticated } from "./pages/auth/Authenticated";
import { Unauthenticated } from "./pages/auth/Unauthenticated";
import { Router } from "./router/router";


i18n
  .use(LanguageDetector)
  .use(Backend)
  .use(initReactI18next)
  .init({
    backend: {
      loadPath: '/locales/{{lng}}.json'
    },
    detection: {
      order: ['cookie', 'localStorage', 'sessionStorage', 'navigator', 'querystring', 'htmlTag', 'path', 'subdomain']
    },
    fallbackLng: "tr",
    interpolation: {
      escapeValue: false // react already safes from xss => https://www.i18next.com/translation-function/interpolation#unescape
    }
  });


function App() {
  const { authConfig } = useConfig();

  if (!authConfig) {
    return <Loading />
  }

  return <Provider store={store}>
    <Auth0Provider
      domain={authConfig.domain}
      clientId={authConfig.clientId}
      useRefreshTokens={true}
      useRefreshTokensFallback={true}
      cacheLocation="localstorage"
      authorizationParams={{
        redirect_uri: window.location.origin,
        audience: authConfig.audience
      }}>
      <Authenticated>
        <Router routes={routes} isPublic={false} currentAccountRole="user" environment={"development"} />
      </Authenticated>
      <Unauthenticated>
        <Router routes={routes} isPublic={true} currentAccountRole="user" environment={"development"} />
      </Unauthenticated>
    </Auth0Provider>
  </Provider>
}

export default App
