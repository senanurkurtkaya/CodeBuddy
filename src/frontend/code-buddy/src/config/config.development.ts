import type { EnvConfig } from "./shared";


export const config: EnvConfig = {
    baseUrl: "https://localhost:7001",
    authConfig: {
        domain: "dev-fbd3mx3pguvhbzu6.us.auth0.com",
        clientId: "J1Imkya7FVoMrOpDliiIsRQpSsKikI8Q",
        redirectUri: window.location.origin,
        audience: "https://codebuddy.com",
        scopes: [
            "openid", 
            "profile", 
            "email",
            "offline_access"
        ],
        defaultScopes: "openid profile email offline_access"
    },
    socialMediaLinks: {
        instagram: "https://www.instagram.com/modilistcom/",
        facebook: "https://www.facebook.com/modilistcom",
        twitter: "https://twitter.com/modilistcom",
        linkedIn: "https://www.linkedin.com/company/modilist/"
    }
};

