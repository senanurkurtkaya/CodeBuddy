import { Outlet } from "react-router";
import { Tabs } from "./Tabs";

export default function Main() {
    return <div>
        <Tabs />
        <Outlet />
    </div>
}