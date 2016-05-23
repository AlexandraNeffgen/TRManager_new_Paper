@MappedSuperclass
public abstract class LazyObject {

	@JsonProperty("ID")
	@Id
	@GeneratedValue(strategy=GenerationType.AUTO)
	@Column(name = "id", unique = true, nullable = false)
	private Integer ID = null;

	@JsonIgnore
	@Transient
	private boolean isLoaded;

	@JsonCreator
	public LazyObject(@JsonProperty("ID") Integer ID) {
		setId(ID);
	}

	@JsonProperty("ID")
	public int getId() {
		return ID;
	}

	@JsonProperty("ID")
	public void setId(Integer id) {
		if (id == null) {
			this.ID = -1;
		} else {
			this.ID = id;
		}
	}

	protected LazyObject() {
		ID = null;
	}

	@JsonIgnore
	public boolean getIsLoaded() {
		return isLoaded;
	}

	@JsonIgnore
	public void setIsLoaded(boolean isLoaded) {
		this.isLoaded = isLoaded;
	}
	
	@Override
	public boolean equals(Object obj) {
		if (obj == null) {
			return false;
		}
		if (obj == this) {
			return true;
		}
		if (!(obj instanceof LazyObject)) {
			return false;
		}
		LazyObject that = (LazyObject) obj;
		return this.ID == that.ID;
	}

	@Override
	public int hashCode() {
		return super.hashCode();
	}
}