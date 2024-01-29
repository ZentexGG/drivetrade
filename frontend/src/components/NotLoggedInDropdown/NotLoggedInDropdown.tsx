import Link from "next/link";
import SignUpTooltip from "../SignUpTooltip/SignUpTooltip";

export default function NotLoggedInDropdown() {
  return (
    <div className="dropdown dropdown-end">
      <div tabIndex={0} role="button" className="btn btn-ghost rounded-btn">
        Account
      </div>
      <ul
        tabIndex={0}
        className="menu dropdown-content z-[1] p-2 shadow bg-base-300 rounded-box w-72 mt-4"
      >
        <li>
          <Link href="/login">Log in</Link>
        </li>
        <li>
          <Link href="/sign-up">Sign up</Link>
        </li>
        <li>
          <SignUpTooltip />
        </li>
      </ul>
    </div>
  );
}
