import { AuthConfig } from "angular-oauth2-oidc";
import { environment } from "../../../environments/environment";
export const authConfig: AuthConfig = {

    issuer: environment.IssuerUri,
    requireHttps: environment.RequireHttps,
    clientId: "UserManagementUI",
    postLogoutRedirectUri: environment.Uri,
    redirectUri: environment.Uri + "/login-callback",
    scope: "openid profile email jp_api.user",
    oidc: true
};
