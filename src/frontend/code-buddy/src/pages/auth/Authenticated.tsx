import { useAuth0, withAuthenticationRequired } from "@auth0/auth0-react";
import { Loading } from "../../components/loading";
import React, { useEffect, useLayoutEffect } from "react";
import { useAppDispatch, useAppSelector } from "../../store/hooks";
import { useConfig } from "../../config";
import { authSlice } from "../../store/auth/auth";
import { useTranslation } from "react-i18next";

const AuthenticatedInner = (props: React.PropsWithChildren) => {
    const { authConfig } = useConfig();
    const { t } = useTranslation();
    const token = useAppSelector((state) => state.auth.token);
    const dispatch = useAppDispatch();
    const {
        user,
        loginWithRedirect,
        getAccessTokenSilently,
        isLoading
    } = useAuth0();

    useEffect(() => {
        if (!token && !isLoading && authConfig) {

            getAccessTokenSilently({
                authorizationParams: {
                    audience: authConfig.audience,
                    redirect_uri: authConfig.redirectUri,
                    scope: authConfig?.scopes.join(" ")
                }
            }).then(response => {
                console.log(response);
                // TODO: validate jwt
                dispatch(authSlice.actions.setToken(response))
            }).catch(err => {
                // TODO: handle err
                console.log(err);
                if (err.error == "login_required") {
                    loginWithRedirect({
                        authorizationParams: {
                            audience: authConfig.audience,
                            redirect_uri: authConfig.redirectUri,
                            ui_locales: "tr en-GB"
                        }
                    });
                }
            });

        }
    }, [token, isLoading, authConfig]);

    return <React.Fragment>
        {props.children}
    </React.Fragment>
}

const AuthenticatedWrapper = withAuthenticationRequired(AuthenticatedInner, {
    onRedirecting: () => <Loading />
})

export const Authenticated = (props: React.PropsWithChildren) => {
    const { isAuthenticated } = useAuth0();

    return <React.Fragment>
        {isAuthenticated && <AuthenticatedWrapper {...props} />}
    </React.Fragment>
}