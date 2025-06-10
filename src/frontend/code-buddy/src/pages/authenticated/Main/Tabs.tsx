import { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router"

export function Tabs() {
    const location = useLocation();
    const navigate = useNavigate();
    const [current,setCurrent] = useState("");

    useEffect(() => {
        if (location) {
            const parts = location.pathname.split("/");
            const partsLength = parts.length;
            
            const lastPath = parts[partsLength - 1];
            if (lastPath === "") {
                setCurrent("latest");
            }
            else {
                setCurrent(lastPath);
            }
        }
    }, [location])

    const handleTabChange = (tab: string) => {
        navigate(`/${tab}`)
    }

    return <div role="tablist" className="tabs tabs-border">
        <a role="tab" onClick={() => handleTabChange("")} className={`tab ${current === "latest" ? "tab-active": ""}`}>Latest</a>
        <a role="tab" onClick={() => handleTabChange("popular")} className={`tab ${current === "popular" ? "tab-active": ""}`}>Popular</a>
        <a role="tab"  onClick={() => handleTabChange("most-viewed")} className={`tab ${current === "most-viewed" ? "tab-active": ""}`}>Most Viewed</a>
    </div>
}