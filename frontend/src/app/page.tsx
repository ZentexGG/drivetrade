import DataFetch from "@/components/DataFetch/DataFetch";
import WelcomeText from "@/components/WelcomeText/WelcomeText";

export default async function Home() {
  let cars = await DataFetch("https://localhost:7191/api/brand");
  console.log(cars);
  return (
    <div>
      <WelcomeText />
      <table>
        {cars?.map((brand : any) => (
          <tr>
            <td>{brand.id}</td>
            <td>{brand.name}</td>
          </tr>
        ))}
      </table>
    </div>
  );
}
