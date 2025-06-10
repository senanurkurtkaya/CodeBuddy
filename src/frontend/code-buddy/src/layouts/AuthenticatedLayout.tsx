import React from "react";
import { Outlet } from "react-router";
import type { RouteConfig } from "../router/routes";
import { Header } from "./shared/Header";

export function AuthenticatedLayout() {
    return <div>
        <Header />
        <div className="w-5xl mx-auto my-4">
            <Outlet />
        </div>
    </div>
}

const MainPage = React.lazy(() => import("../pages/authenticated/Main/Main"));
const QuestionsFeedPage = React.lazy(() => import("../pages/authenticated/Main/QuestionsFeed"));
const CreateQuestionPage = React.lazy(() => import("../pages/authenticated/CreateQuestion/CreateQuestion"));

export const authenticatedRoutes: RouteConfig = {
    path: "/",
    element: <AuthenticatedLayout />,
    isPublic: false,
    leafNodes: [
        {
            path: "",
            element: <MainPage />,
            leafNodes: [
                {
                    path: "",
                    element: <QuestionsFeedPage />
                },
                {
                    path: "popular",
                    element: <QuestionsFeedPage />
                },
                {
                    path: "most-viewed",
                    element: <QuestionsFeedPage />
                }
            ]
        },
        {
            path: "questions/create",
            element: <CreateQuestionPage />
        }
    ]
}