import { FiLoader } from "react-icons/fi";

const Loading = () => {
  return (
    <div className="absolute w-full h-full left-0 top-0 backdrop-blur-xs flex justify-center items-center z-50">
      {/* <p className="text-3xl">Loading....</p> */}
      <FiLoader className="text-4xl animate-spin" style={{animation: "spin 3s linear infinite"}} />
    </div>
  );
};

export default Loading;
