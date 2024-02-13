import MileageOptions from "../MileageOptions/MileageOptions";

export default function CarMileageInput() {
  return (
    <>
      <div className="form-control">
        <input
          type="number"
          placeholder="From (KM)"
          className="input input-bordered input-secondary w-full max-w-xs"
          name="mileageStart"
          list="mileage-to"
        />
        <datalist id="mileage-to">
          <MileageOptions />
        </datalist>
      </div>
      <div className="form-control">
        <input
          type="number"
          placeholder="To (KM)"
          className="input input-bordered input-secondary w-full max-w-xs"
          name="mileageEnd"
        />
      </div>
    </>
  );
}
