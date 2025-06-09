import { useEffect, useState } from "react";
import { useLocation } from "react-router";

export default function QuestionsFeed() {
    const location = useLocation();
    const [current, setCurrent] = useState("");

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

    return <div>
        Feed
    </div>
}