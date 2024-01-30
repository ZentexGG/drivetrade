  import Link from "next/link";
  import { Archivo_Black } from "next/font/google";
  import { VscAdd } from "react-icons/vsc";
  import NotLoggedInDropdown from "../NotLoggedInDropdown/NotLoggedInDropdown";
  import SignUpTooltip from "../SignUpTooltip/SignUpTooltip";
  import NotLoggedInDrawer from "../NotLoggedInDrawer/NotLoggedInDrawer";

  const archivo = Archivo_Black({
    subsets: ["latin", "latin-ext"],
    weight: ["400"],
  });

  export default function Navbar() {
    return (
      <div className="drawer z-10">
        <input id="navbar-drawer" type="checkbox" className="drawer-toggle" />
        <div className="drawer-content flex flex-col">
          {/* Navbar */}
          <div className="w-full navbar bg-base-300">
            <div className="flex-none lg:hidden">
              <label
                htmlFor="navbar-drawer"
                aria-label="open sidebar"
                className="btn btn-square btn-ghost"
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  className="inline-block w-6 h-6 stroke-current"
                >
                  <path
                    strokeLinecap="round"
                    strokeLinejoin="round"
                    strokeWidth="2"
                    d="M4 6h16M4 12h16M4 18h16"
                  ></path>
                </svg>
              </label>
            </div>
            <div className={`${archivo.className} flex-1 px-2 mx-2 text-2xl`}>
              <Link href="/" className="btn btn-ghost text-xl">
                DRIVETRADE
              </Link>
            </div>
            <div className="lg:flex lg:justify-end lg:flex-1 lg:px-2 hidden">
              <div className="flex items-stretch">
                <Link href="/" className="btn btn-secondary rounded-btn mr-3">
                  <VscAdd /> Sell your car
                </Link>

                {/* TODO: Add if else for logged in or not logged in when you get info */}

                <NotLoggedInDropdown />
              </div>
            </div>
          </div>
          {/* Rest of page content goes here */}
        </div>
        <NotLoggedInDrawer />
      </div>
    );
  }
