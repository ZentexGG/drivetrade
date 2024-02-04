import CarSearch from "@/components/CarSearch/CarSearch";
import WelcomeText from "@/components/WelcomeText/WelcomeText";

export default async function Home() {
  return (
    <div>
      <WelcomeText />
      <CarSearch />
    </div>
  );
}
