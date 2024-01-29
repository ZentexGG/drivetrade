export default function SignUpTooltip() {
  return (
    <>
      <div className="collapse collapse-plus bg-base-200 h-25">
        <input type="checkbox" />
        <div className="collapse-title text-xl font-medium">
          Don't have an account yet?
        </div>
        <div className="collapse-content">
          <p>
            <a href="/sign-up" className="underline">
              Sign up
            </a>{" "}
            right now and start selling for free!
          </p>
        </div>
      </div>
    </>
  );
}
