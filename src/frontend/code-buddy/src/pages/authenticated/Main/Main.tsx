import { Outlet, useNavigate } from "react-router";
import { Tabs } from "./Tabs";

export default function Main() {
    const navigate = useNavigate();

    return <div>
        <div className="flex justify-between">
            <Tabs />
            <button className="btn btn-secondary" onClick={() => navigate("questions/create")}>Ask Question</button>
        </div>
        <Outlet />
    </div>
}