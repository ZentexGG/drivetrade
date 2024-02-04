import React from "react";
import "@/app/FadeInAnimation.scss";
import axios from "@/lib/axios";
import Image from "next/image";

export default async function WelcomeText() {
    let vehicleReq = await axios.get<any>("/api/vehicle/1");
    const res = vehicleReq.data;
  // console.log(res);
  // console.log(res.Photos['$values'][0].ImageData)
  return (
    <div className="text-center font-extrabold">
      <h1 className="fadeInUp text-6xl">Welcome to DriveTrade</h1>
      <p style={{ animationDelay: "1s" }} className="fadeInUp text-lg">
        Your one stop shop for used vehicles
      </p>
      {/* <Image
        src={`data:image/jpeg;base64,${res.Photos["$values"][0].ImageData}`}
        alt="Photograph of motorcar"
        fill={true}
      /> */}
    </div>
  );
}
