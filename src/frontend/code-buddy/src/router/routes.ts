/* eslint-disable @typescript-eslint/no-unused-vars */
import React from "react";
import { authenticatedRoutes } from "../layouts/AuthenticatedLayout";
import { unauthenticatedRoutes } from "../layouts/UnauthenticatedLayout";


type Environments = "production" | "staging" | "int" | "development";

type Roles = "Admin" | "User";

export interface RouteConfig {
    path: string;
    element: React.ReactNode;
    isPublic?: boolean;
    roles?: string[];
    disabledEnvironments?: Environments[];
    leafNodes?: RouteConfig[];
    loading?: React.ReactNode;
    error?: React.ReactNode;
    menuItem?: {
        name: string;
        icon: React.ReactNode;
    }
}

export const routes: RouteConfig[] = [
    authenticatedRoutes,
    unauthenticatedRoutes
];