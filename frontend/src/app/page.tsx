import CarSearch from "@/components/CarSearch/CarSearch";
import DataFetch from "@/components/DataFetch/DataFetch";
import WelcomeText from "@/components/WelcomeText/WelcomeText";

export default async function Home() {
  return (
    <div>
      <WelcomeText />
      <CarSearch />
    </div>
  );
}
