import CarSearch from "@/components/CarSearch/CarSearch";
import DataFetch from "@/components/DataFetch/DataFetch";
import WelcomeText from "@/components/WelcomeText/WelcomeText";

export default async function Home() {
  let cars = await DataFetch("https://localhost:7191/api/brand");
  console.log(cars);
  return (
    <div>
      <WelcomeText />
      <CarSearch />
    </div>
  );
}
