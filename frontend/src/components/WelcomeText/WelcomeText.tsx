import React from "react";
import "./WelcomeText.scss";

export default function WelcomeText() {
  return (
    <div className="text-center font-extrabold">
      <h1 className="fadeInUp text-6xl">Welcome to DriveTrade</h1>
      <p style={{ animationDelay: "2s" }} className="fadeInUp text-lg">
        Your one stop shop for used vehicles
      </p>
    </div>
  );
}
