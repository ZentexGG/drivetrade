import SignUpTooltip from "../SignUpTooltip/SignUpTooltip";
import { SlArrowLeft } from "react-icons/sl";
import CloseDrawer from "../CloseDrawer/CloseDrawer";

export default function NotLoggedInDrawer() {
  return (
    <div className="drawer-side">
      <label
        htmlFor="navbar-drawer"
        aria-label="close sidebar"
        className="drawer-overlay"
      ></label>
      <ul className="menu p-4 w-80 min-h-full bg-base-300">
        {/* Sidebar content here */}
        <li>
          <CloseDrawer>
            <SlArrowLeft size={23} />
          </CloseDrawer>
        </li>
        <li>
          <a href="/">Home</a>
        </li>
        <li>
          <a href="/login">Log in</a>
        </li>
        <li>
          <a href="/sign-up">Sign up</a>
        </li>
        <li>
          <SignUpTooltip />
        </li>
      </ul>
    </div>
  );
}
