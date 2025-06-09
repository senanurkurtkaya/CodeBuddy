import { useEffect, useRef, useState } from "react";
import { Authenticated } from "../../pages/auth/Authenticated";
import { Unauthenticated } from "../../pages/auth/Unauthenticated";
import { useAuth0 } from "@auth0/auth0-react";

function UserMenu() {
    const { logout } = useAuth0();
    const [userMenuOpen, setUserMenuOpen] = useState(false);
    const menuRef = useRef<any>(null);

    // Close menu when clicking outside
    useEffect(() => {
        function handleClickOutside(event: any) {
            if (menuRef.current && !menuRef.current.contains(event.target)) {
                setUserMenuOpen(false);
            }
        }
        document.addEventListener("mousedown", handleClickOutside);
        return () => document.removeEventListener("mousedown", handleClickOutside);
    }, []);

    const handleLogout = () => {
        logout();
    }

    return <div className="flex-none" ref={menuRef}>
        <div className={`dropdown dropdown-end ${userMenuOpen ? "dropdown-open" : ""}`}>
            <label
                tabIndex={0}
                className="btn btn-ghost btn-circle avatar"
                onClick={() => setUserMenuOpen(!userMenuOpen)}
                aria-haspopup="true"
                aria-expanded={userMenuOpen}
                aria-label="User menu"
            >
                <div className="w-10 rounded-full">
                    <img src="https://i.pravatar.cc/40" alt="User Avatar" />
                </div>
            </label>
            <ul
                tabIndex={0}
                className="menu menu-compact dropdown-content mt-3 p-2 shadow bg-base-300 rounded-box w-40 font-medium text-gray-200"
            >
                <li><a href="#profile" className="hover:text-indigo-400">Profile</a></li>
                <li><a href="#account" className="hover:text-indigo-400">Account</a></li>
                <li><a href="#logout" className="text-red-500 hover:text-red-400" onClick={handleLogout}>Logout</a></li>
            </ul>
        </div>
    </div>
}

function LoginButton() {
    const { loginWithRedirect } = useAuth0();

    const handleLogin = () => {
        loginWithRedirect();
    }

    return <button className="btn btn-primary" onClick={handleLogin}>
        Login
    </button >
}

export function Header() {


    return <div className="navbar bg-base-200 shadow px-6">
        <div className="flex">
            <a className="btn btn-ghost normal-case text-2xl font-mono text-indigo-400 cursor-pointer">
                CodeBuddy
            </a>
        </div>

        <div className="navbar-start flex-1 hidden lg:flex">
            <ul className="menu menu-horizontal p-0 font-medium text-gray-300">
                <li><a className="hover:text-indigo-400">Home</a></li>
                <li><a className="hover:text-indigo-400">Top Questions</a></li>
                <li><a className="hover:text-indigo-400">Blog</a></li>
                <li><a className="hover:text-indigo-400">Contacts</a></li>
                <li><a className="hover:text-indigo-400">Jobs</a></li>
            </ul>
        </div>
        <input type="text" placeholder="Search" className="input input-bordered w-24 md:w-auto mr-4" />

        <Authenticated>
            <UserMenu />
        </Authenticated>
        <Unauthenticated>
            <LoginButton />
        </Unauthenticated>
    </div>
}