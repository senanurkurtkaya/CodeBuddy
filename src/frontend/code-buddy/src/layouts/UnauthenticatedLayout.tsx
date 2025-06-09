import React from "react";
import { Outlet } from "react-router-dom";
import type { RouteConfig } from "../router/routes";
import { Header } from "./shared/Header";

export function UnauthenticatedLayout() {

    return <div>
        <Header />
        <Outlet />
    </div>
}

const LandingPage = React.lazy(() => import("../pages/unauthenticated/Landing"));

export const unauthenticatedRoutes: RouteConfig = {
    path: "/",
    element: <UnauthenticatedLayout />,
    isPublic: true,
    leafNodes: [
        {
            path: "",
            element: <LandingPage />
        }
    ]
}