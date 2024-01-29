export default function CloseDrawer({children} : {children: React.ReactNode}) {
  return (
    <label
      htmlFor="navbar-drawer"
      aria-label="close sidebar"
      className="drawer-overlay"
      >
          {children}
    </label>
  );
}
