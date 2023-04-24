namespace Test_A_14
{
    public class SecurityExchangeProcessService
    {
        private readonly SecurityExchangeProcessRepository _repository;

        public SecurityExchangeProcessService(SecurityExchangeProcessRepository repository)
        {
            _repository = repository;
        }

        public void Create(SecurityExchangeProcessDTO processDTO)
        {
            var process = new SecurityExchangeProcess
            {
                // Map properties from DTO
            };

            _repository.Create(process);
        }

        public SecurityExchangeProcessDTO Get(int id)
        {
            var process = _repository.Get(id);

            // Map properties to DTO
            var processDTO = new SecurityExchangeProcessDTO
            {
                // Map properties
            };

            return processDTO;
        }

        public List<SecurityExchangeProcessDTO> GetAll()
        {
            var processes = _repository.GetAll();
            var processDTOs = new List<SecurityExchangeProcessDTO>();

            // Map each process to DTO
            foreach (var process in processes)
            {
                processDTOs.Add(new SecurityExchangeProcessDTO
                {
                    // Map properties
                });
            }

            return processDTOs;
        }

        public void Update(SecurityExchangeProcessDTO processDTO)
        {
            var process = new SecurityExchangeProcess
            {
                // Map properties from DTO
            };

            _repository.Update(process);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}