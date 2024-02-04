import axios from "@/lib/axios";
import DataFetch from "../DataFetch/DataFetch";

export default async function CarBrandSelect() {
  let brandsReq = await axios.get<CarBrand[]>("/api/brand");
  const brands = brandsReq.data;
  return (
    <select
      className="select select-secondary w-full max-w-xs"
      defaultValue="none"
      name="brand"
    >
      <option disabled value="none">
        Pick a brand
      </option>
      {brands?.map((brand: CarBrand) => (
        <option key={brand.id} value={brand.id}>{brand.name}</option>
      ))}
    </select>
  );
}
