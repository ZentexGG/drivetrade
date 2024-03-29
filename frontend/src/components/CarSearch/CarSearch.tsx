import "@/app/FadeInAnimation.scss";
import CarBrandSelect from "../CarBrandSelect/CarBrandSelect";
import CarMileageInput from "../CarMileageInput/CarMileageInput";
import { useState } from "react";

export default function CarSearch() {
  const [errMsg, setErrMsg] = useState("");
  async function StartSearch(formData: FormData) {
    "use server";
    const rawFormData = {
      keywords: formData.get("keywords"),
      brand: formData.get("brand"),
      mileageStart: parseFloat(formData.get("mileageStart") as string),
      mileageEnd: parseFloat(formData.get("mileageEnd") as string)
    };

    if (rawFormData.mileageStart > rawFormData.mileageEnd) {
      console.log("Starting mileage can not be bigger than end mileage");
      return;
    }

    console.log(rawFormData);
  }

  return (
    <div
      style={{ animationDelay: "2s" }}
      className="hero min-h-screen bg-base-100 fadeInUp"
    >
      <div className="hero-content flex-col lg:flex-row-reverse">
        <div className="text-center lg:text-left">
          <h1 className="text-5xl font-bold">Start your search now</h1>
          <p className="py-6">
            Looking for a car? <br /> Start by applying some filters for your
            search in order to narrow down on what you're looking for.
          </p>
        </div>
        <div className="card shrink-0 w-full max-w-sm shadow-2xl bg-base-100">
          <form className="card-body" action={StartSearch}>
            <div className="form-control">
              <input
                type="text"
                placeholder="Keywords"
                className="input input-bordered input-secondary"
                name="keywords"
              />
            </div>
            <div className="form-control">
              <CarBrandSelect />
            </div>
            <div className="flex space-x-4">
              <CarMileageInput />
            </div>
            <div className="form-control mt-6">
              <h1>{errMsg}</h1>
              <button type="submit" className="btn btn-primary">
                Search
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}
