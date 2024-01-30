import "@/app/FadeInAnimation.scss";
import CarBrandSelect from "../CarBrandSelect/CarBrandSelect";

export default function CarSearch() {
  return (
    <div  style={{ animationDelay: "2s" }} className="hero min-h-screen bg-base-200 fadeInUp">
      <div className="hero-content flex-col lg:flex-row-reverse">
        <div className="text-center lg:text-left">
          <h1 className="text-5xl font-bold">Start your search now</h1>
          <p className="py-6">
            Looking for a car? <br /> Start by applying some filters for your search in order to narrow down on what you're looking for.
          </p>
        </div>
        <div className="card shrink-0 w-full max-w-sm shadow-2xl bg-base-100">
          <form className="card-body">
            <div className="form-control">
              <input
                type="text"
                placeholder="Keywords"
                className="input input-bordered"
                required
              />
            </div>
            <div className="form-control">
              <CarBrandSelect />
              <label className="label">
                <a href="#" className="label-text-alt link link-hover">
                  Forgot password?
                </a>
              </label>
            </div>
            <div className="form-control mt-6">
              <button className="btn btn-primary">Login</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}
