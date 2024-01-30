import DataFetch from "../DataFetch/DataFetch";

export default async function CarBrandSelect() {

    const brands : CarBrand[] = await DataFetch("https://localhost:7191/api/brand")

  return (
    <select className="select select-secondary w-full max-w-xs" defaultValue="none">
      <option disabled value="none">
        Pick a brand
          </option>
          {brands?.map((brand : CarBrand) => <option>{brand.name}</option>)}
    </select>
  );
}
